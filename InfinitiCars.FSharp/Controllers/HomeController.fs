namespace InfinitiCars.FSharp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

type HomeController() =
    inherit Controller()

    member x.Index () = 
        let message="Home Page"
        x.ViewData.["Title"] <- message
        x.View()