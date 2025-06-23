using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IBranchRepository for Branch-specific operations using Entity Framework Core
/// Inherits basic CRUD from <see cref="RepositoryBase{Branch}"/>
/// </summary>
public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    /// <summary>
    /// Initializes a new instance of BranchRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public BranchRepository(DefaultContext context) : base(context) { }
}