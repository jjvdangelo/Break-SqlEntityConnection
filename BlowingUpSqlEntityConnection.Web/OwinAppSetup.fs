﻿module OwinAppSetup

open System
open System.Collections.Generic
open System.Threading.Tasks
open Simple.Web

type UseAction = Action<Func<IDictionary<string, obj>, Func<IDictionary<string, obj>, Task>, Task>>

type OwinAppSetup() =
    static member Setup(useMethod:UseAction) =
        Application.LegacyStaticContentSupport <- true
        let run x y = Application.Run(x, y)
        run |> useMethod.Invoke

type StaticContentStartup() =
    interface IStartupTask with
        member __.Run(config, env) =
            let pf f = config.PublicFolders.Add(PublicFolder f) |> ignore
            ["/Scripts"; "/Content"; "/App"] |> List.iter pf

            let pfm (uri, pf) = config.PublicFileMappings.Add(uri, PublicFile pf)
            [("/", "/views/index.html")] |> List.iter pfm
        
open System.Web.Hosting
open Simple.Web.Helpers

type PathUtility() =
    interface IPathUtility with
        member __.MapPath virtualPath =
            virtualPath |> HostingEnvironment.MapPath