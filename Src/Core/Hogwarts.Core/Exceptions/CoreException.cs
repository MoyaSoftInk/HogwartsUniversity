namespace Hogwarts.Core.Exceptions
{

    using System;

    /// <summary>
    /// Core Exception
    /// </summary>
    public abstract class CoreException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        protected CoreException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The p_ message.</param>
        protected CoreException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        protected CoreException(string message, Exception ex)
            : base(message, ex)
        {
        }

        /// <summary>
        /// Gets the unique id.
        /// </summary>
        /// <value>The unique id.</value>
        public Guid UniqueId { get; } = Guid.NewGuid();
    }
}
