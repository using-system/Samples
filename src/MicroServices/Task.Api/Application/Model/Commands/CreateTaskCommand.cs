namespace Task.Api.Application.Model
{
    using MediatR;

    /// <summary>Create Task Command</summary>
    public class CreateTaskCommand : IRequest<int>
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}
