using Blogy.Business.DTOs.BlogDtos;

namespace Blogy.Business.Services;

/// <summary>
/// Defines a generic contract for CRUD-style operations for a given entity,
/// exposing DTOs for result, update, and create workflows.
/// </summary>
/// <typeparam name="TEntity">The domain entity type this service manages.</typeparam>
/// <typeparam name="TResult">The DTO shape returned when listing or querying results.</typeparam>
/// <typeparam name="TUpdate">The DTO shape used for reading/updating an existing entity.</typeparam>
/// <typeparam name="TCreate">The DTO shape used when creating a new entity.</typeparam>
public interface IGenericService<TResult, TUpdate, TCreate>
{
    /// <summary>
    /// Retrieves the update DTO for the entity identified by the specified id.
    /// Typically used to prefill update forms.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task that completes with the update DTO.</returns>
    Task<TUpdate> GetByIdAsync(int id); // Burada TUpdate kullanmamın sebebi, güncelleme işlemi için gerekli olan verileri döndürmek istemem.

    /// <summary>
    /// Creates a new entity using the provided create DTO.
    /// </summary>
    /// <param name="createDto">The create DTO containing the data for the new entity.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CreateAsync(TCreate createDto);

    /// <summary>
    /// Retrieves all blogs projected to <see cref="ResultBlogDto"/>.
    /// </summary>
    /// <remarks>
    /// This is a specialized convenience method for blog results.
    /// </remarks>
    /// <returns>A task that returns the collection of blog result DTOs.</returns>
    Task<IList<ResultBlogDto>> GetAllAsync();

    /// <summary>
    /// Updates an existing entity using the provided update DTO.
    /// </summary>
    /// <param name="updateDto">The update DTO containing the modified data.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(TUpdate updateDto);

    /// <summary>
    /// Deletes the entity identified by the specified id.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(int id);
}
