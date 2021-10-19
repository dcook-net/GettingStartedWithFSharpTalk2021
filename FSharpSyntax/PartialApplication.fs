module PartialApplication

let add a b = a+b

let mutate valueToMutate mutator =
    mutator valueToMutate

let result = add 5 10 // result = 15

let addFive = add 5 // returns new function
                    // - still requires b
let result2 = addFive 10 // result2 = 15

let result3 = mutate 10 addFive // result3 = 15


module PartialApplicationUsedForComposition =

    open System
    open System.Globalization
    
    let toChar n = Convert.ToChar(n.ToString())
    let toLower culture (s:string) = s.ToLower(culture) 
    let trim (s:string) = s.Trim()
    
    let filter charsToFilter (s:string) =
        s.ToCharArray()
        |> Array.fold (fun acc elem ->
            if List.contains elem charsToFilter
            then acc
            else acc + elem.ToString() ) "" 
        
    let filterNumbers =
        filter ['0';'1';'2';'3';'4';'5';'6';'7';'8';'9']
        
    let filterNumbersV2 = [ 0 .. 9 ] |> List.map toChar |> filter
        
    let filterSpecialChars = filter ['$';'%';'^';'&']

        
    let sillyCypher = Map.empty.Add('a', "1").Add('b', "2").Add('c', "3").Add('d', "4")

    let simpleEncrypt (characterMap:Map<char,string>) (s:string) =
        s.ToCharArray()
        |> Array.map (fun c ->
                    c
                    |> characterMap.TryGetValue
                    |> function 
                        | true, value -> value
                        | false, _ -> c.ToString())
        |> Array.toList

    let transformStringV1 s =
        s
        |> toLower CultureInfo.InvariantCulture
        |> (filter ([ 0 .. 9 ] |> List.map toChar))
        |> (filter ['$';'%';'^';'&'])
        |> trim
        |> simpleEncrypt sillyCypher
        |> List.fold (fun acc elem -> acc + elem) ""
    
    let lowercase = toLower CultureInfo.InvariantCulture

    let encrypt = simpleEncrypt sillyCypher
    
    let toString = List.fold (fun acc elem -> acc + elem) ""
    
    let transformStringV2 s =
        s                       // " 1234567890 $%^& abcdefg ABCDEFG "
        |> lowercase            // " 1234567890 $%^& abcdefg abcdefg "
        |> filterNumbers        // "  $%^& abcdefg abcdefg "
        |> filterSpecialChars   // "   abcdefg abcdefg "
        |> trim                 // "abcdefg abcdefg"
        |> encrypt           // ["1234efg ","1234efg"] 
        |> toString                  //  "1234efg 1234efg"
        