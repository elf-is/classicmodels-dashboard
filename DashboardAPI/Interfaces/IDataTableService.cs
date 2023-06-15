using Dashboard.Data.DTO;

namespace Dashboard.Interfaces;

public interface IDataTableService<T> where T : class
{
    /// <summary>
    ///     Get the data from the database
    /// </summary>
    /// <returns>A IQueryable of the data</returns>
    IQueryable<T> GetData();

    /// <summary>
    ///     Get the dataTable data after searching and ordering
    /// </summary>
    /// <param name="request">The <see cref="DatatableRequest" /> object</param>
    /// <param name="model">The requested model to process</param>
    /// <returns>A <see cref="DatatableResponse{T}" /> object</returns>
    DatatableResponse<T> GetDatatableObject(DatatableRequest request, IQueryable<T> model);
}