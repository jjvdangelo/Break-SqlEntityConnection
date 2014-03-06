namespace BlowingUpSqlEntityConnection.Web.Data

open Microsoft.FSharp.Data.TypeProviders

type internal EntityContext = SqlEntityConnection<ConnectionStringName="default", Pluralize = false, ForceUpdate = true>