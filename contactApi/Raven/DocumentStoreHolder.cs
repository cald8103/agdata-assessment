using System.Collections.Immutable;
using Raven.Client;
using Raven.Client.Documents;

namespace ContactApi.Raven;

public static class DocumentStoreHolder
{
    private static readonly Lazy<IDocumentStore> LazyStore = new Lazy<IDocumentStore>(() =>
    {
        IDocumentStore store = new DocumentStore
        { 
            Urls = new[] { "http://127.0.0.1:8080" },
            Database = "contactdb"
        };
        store.Initialize();
        return store;
    });
    public static IDocumentStore Store => LazyStore.Value;
}