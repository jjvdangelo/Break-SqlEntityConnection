namespace BlowingUpSqlEntityConnection.Web

open Simple.Web
open BlowingUpSqlEntityConnection.Web.Data
    
type Result = { Id: int; Value: int }

[<UriTemplate("/foo/{Id}/bars")>]
type Index() as this =

    let getEntity() =
        use conn = EntityContext.GetDataContext()
        query { for t1 in conn.Table_1 do
                join t2 in conn.Table_2 on (t1.id = t2.table_1_id)
                where (t1.id = this.Id)
                select t2
                headOrDefault } |> function
        | null -> Unchecked.defaultof<_>
        | t2 -> { Id = t2.id; Value = t2.value }

    member val Id = null with get, set
    member val Result = Unchecked.defaultof<_> with get, set

    interface IGet with
        member this.Get() =
            try
                this.Result <- getEntity()
            with
            | e -> e |> System.Diagnostics.Trace.WriteLine

            match this.Result = Unchecked.defaultof<_> with
            | true -> Status 413
            | false -> Status 200