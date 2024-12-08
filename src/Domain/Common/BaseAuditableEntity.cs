namespace Domain.Common;

public abstract class BaseAuditableEntity<T> : BaseEntity<T>
{
    /// <summary>
    /// Gets or sets the username of the entity creator.
    /// </summary>
    public string? CreatedBy { get; set; }
    
    /// <summary>
    /// Gets or sets the username of the last modifier.
    /// </summary>
    public string? LastModifiedBy { get; set; }
    
    /// <summary>
    /// Gets or sets the datetime when the entity was last create.
    /// </summary>
    public DateTimeOffset Created { get; set; }
    
    /// <summary>
    /// Gets or sets the datetime when the entity was last modified.
    /// </summary>
    public DateTimeOffset LastModified { get; set; }
}
