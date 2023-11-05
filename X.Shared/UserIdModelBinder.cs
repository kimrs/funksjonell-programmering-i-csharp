using FunksjonellProgrammering.Shared.Primitives;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace FunksjonellProgrammering.Shared;

public class UserIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var strValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;
        UserId id = int.Parse(strValue);
        bindingContext.Result = ModelBindingResult.Success(id);
        
        return Task.CompletedTask;
    }
}

public class UserIdModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
        => context.Metadata.ModelType == typeof(UserId)
            ? new BinderTypeModelBinder(typeof(UserIdModelBinder))
            : (IModelBinder) null;
}