[![Build Status](https://dev.azure.com/fluxera/Foundation/_apis/build/status/GitHub/fluxera.Fluxera.Temporal?branchName=main)](https://dev.azure.com/fluxera/Foundation/_build/latest?definitionId=71&branchName=main)

# Fluxera.Temporal
A libary that provides temporal types.


## Serialization Support

At the moment serialization support is available for:

- [MongoDB](https://github.com/mongodb/mongo-csharp-driver)

### MongoDB

To support the temporal serializers in MongoDB use the ```UseTemporal``` extension method on a ```ConventionPack```.

```C#
ConventionPack pack = new ConventionPack();
pack.UseTemporal();
ConventionRegistry.Register("ConventionPack", pack, t => true);
```
