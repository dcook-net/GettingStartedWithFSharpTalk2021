# Getting Started With F#

[Slide Deck](GettingStartedWithFSharp.pptx), code samples, and [learning resources](Resources.md) for 'Getting Started With F#' talk for Peterborough .Net.

Code Samples created using .Net 5.0, F# 5.0, and C# 9.0, so will require a 5.x.x SDK installed.
Some tests require Mongo be be running.

From the main dir where you clone this repo:

```bash
docker run -d --rm -p 27017:27017 mongo:4.2.15

dotnet test
```
