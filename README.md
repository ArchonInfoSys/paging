# Paging Utilities

> Simple paging model and extension methods to help page data.

## How to Use

Install via [nuget](https://www.nuget.org/packages/Archon.Paging/)

```
install-package Archon.Paging
```

Make sure to add `using Paging;` to the top of your files to get access to any of the following extension methods.

### The Pagination Model

With any `IQueryable<T>`, just call `AsPagination` on it to get back a `Pagination<T>` model. Internally, the `AsPagination` extension method will call `Count` on the queryable to calculate the total count and execute the appropriate `Skip` and `Take` methods to properly page the data.

The resulting `Pagination` model is optimized to serialize nicely into JSON and properly deserialize from JSON.
