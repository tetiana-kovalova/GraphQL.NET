using GraphQL;
using GraphQL.Types;
using GraphQLProductApp.Data;
using GraphQLProductApp.Repository;
using System.Collections.Generic;

namespace GraphQLProductApp.GraphQL;

public class ComponentMutation : ObjectGraphType
{
    public ComponentMutation(IComponentRepository componentRepostory)
    {
        Field<ComponentType>("createComponent",
            arguments: new QueryArguments(new List<QueryArgument>
            {
                new QueryArgument<NonNullGraphType<ComponentInputType>>
                {
                    Name = "component"
                }
            }),
            resolve: context =>
            {
                var component = context.GetArgument<Components>("component");
                return componentRepostory.CreateComponent(component);
            });
    }
}