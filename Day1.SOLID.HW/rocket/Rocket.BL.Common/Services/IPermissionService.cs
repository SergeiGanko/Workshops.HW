using System.Collections.Generic;
using Rocket.BL.Common.Models.UserRoles;
using System;
using System.Linq;
using System.Linq.Expressions;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.BL.Common.Services
{
    public interface IPermissionService
    {
        /// <summary>
        /// Добавить существующую функц возможность для выбранной роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void AddPermissionToRole(string idRole, int idPermission);

        /// <summary>
        /// Удалить функц возможность из текущего списка у роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void RemovePermissionFromRole(string idRole, int idPermission);

        /// <summary>
        /// Добавляет пермишен
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="user">The user.</param>
        void Insert(Permission permission, string user);

        /// <summary>
        /// Gets the permission by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissionByUser(string user);

        /// <summary>
        /// Gets all permissions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Permission> GetAllPermissions();

        /// <summary>
        /// Deletes the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="user">The user.</param>
        void Delete(Permission permission, string user);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Permission GetById(string id);

        /// <summary>
        /// Updates the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="user">The user.</param>
        void Update(Permission permission, string user);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IEnumerable<Permission> Get(Expression<Func<DbPermission, bool>> filter,
                                    Func<IQueryable<DbPermission>, IOrderedQueryable<DbPermission>> orderBy,
                                    string includeProperties);
    }
}