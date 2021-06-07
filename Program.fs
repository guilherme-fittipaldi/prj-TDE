// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FSharp.Data


let soma lista = lista |> List.reduce (fun x y -> x + y)
let media lista totalJogadores = (soma lista) / totalJogadores
let print = printfn "%s %f\n"
let printVar = printfn "%s %O"

type Stocks = CsvProvider<"csv\\nba.csv", ";">

[<EntryPoint>]
let main argv =

    let csv = Stocks.Load("csv\\nba.csv")

    // Variáveis: Altura e Peso do jogador
    let alturaJogador = [for r in csv.Rows -> r.Player_height |> float]
    let pesoJogador = [for r in csv.Rows -> r.Player_weight |> float]

    printfn "%s" "\nVariáveis"
    printVar "Altura dos jogadores (cm):" alturaJogador
    printVar "Peso dos jogadores (kg):" pesoJogador

    let alturaJogadorAoQuadrado = [for altura in alturaJogador -> altura ** 2.0]
    let pesoJogadorAoQuadrado = [for peso in pesoJogador -> peso ** 2.0]

    let multAlturaPesoJogador = [for i = 0 to alturaJogador.Length - 1 do (alturaJogador.[i] * pesoJogador.[i])]

    let qtdJogadores = csv.Rows |> Seq.length |> float
    let coeficienteCorrelacao =
        (qtdJogadores * (soma multAlturaPesoJogador) - (soma alturaJogador) * (soma pesoJogador))
        / (Math.Sqrt(qtdJogadores * (soma alturaJogadorAoQuadrado) - (soma alturaJogador) ** 2.0)
        * Math.Sqrt(qtdJogadores * (soma pesoJogadorAoQuadrado) - (soma pesoJogador) ** 2.0))

    let mediaAlturaPesoJogador = (media multAlturaPesoJogador qtdJogadores)
    let mediaAlturaJogador = (media alturaJogador qtdJogadores)
    let mediaPesoJogador = (media pesoJogador qtdJogadores)
    let mediaAlturaJogadorAoQuadrado = (media alturaJogadorAoQuadrado qtdJogadores)

    let a = (mediaAlturaPesoJogador - (mediaAlturaJogador * mediaPesoJogador))/(mediaAlturaJogadorAoQuadrado - (mediaAlturaJogador ** 2.0))
    let b = mediaPesoJogador - a * mediaAlturaJogador

    print "\nCorrelação:" coeficienteCorrelacao
    print "a:" a
    print "b:" b

    0 // return an integer exit code