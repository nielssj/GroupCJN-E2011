// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractDataAccessObject.cs" company="DVL">
//   Jan Meier
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    using global::DigitalVoterList.DBComm.DO;

    /// <summary>
    /// An abstract implementation of the DAO interface. All methods are fully implemented, and 
    /// a concrete implementation need only provide the type of entity that the DAO should return /
    /// work with via the type parameter. 
    /// </summary>
    /// <typeparam name="T">The type of objects this DAO handles.
    /// </typeparam>
    public abstract class AbstractDataAccessObject<T> : IDataAccessObject<T>
        where T : class, IDataObject
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly DigitalVoterList db = new DigitalVoterList();

        /// <summary>
        /// Create this object.
        /// </summary>
        /// <param name="t">
        /// The object to insert.
        /// </param>
        /// <returns>
        /// True if the object was created, false otherwise.
        /// </returns>
        public bool Create(T t)
        {
            db.GetTable<T>().InsertOnSubmit(t);
            db.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Return all of the objects for which this predicate holds.
        /// </summary>
        /// <param name="f">
        /// The predicate to select by (where).
        /// </param>
        /// <returns>
        /// An iterable collection of objects matching the predicate.
        /// </returns>
        public IEnumerable<T> Read(Expression<Func<T, bool>> f)
        {
            return db.GetTable<T>().AsQueryable().Where(f);
        }

        /// <summary>
        /// Update all of the objects for which this predicate holds.
        /// Note that when trying to update the primary key, the dummy 
        /// object must be fully initialized, since the old record will be
        /// deleted, and a new one inserted.
        /// </summary>
        /// <param name="f">
        /// The predicate to select by (where).
        /// </param>
        /// <param name="dummy">
        /// The dummy.
        /// </param>
        /// <returns>
        /// True if the update was successful, false otherwise.
        /// </returns>
        public bool Update(Expression<Func<T, bool>> f, T dummy)
        {
            var oldValues = this.Read(f);

            if (oldValues != null)
            {
                foreach (var oldValue in oldValues)
                {
                    if (oldValue.PrimaryKey != dummy.PrimaryKey)
                    {
                        // Delete the old value and insert a new one, since trying to directly update the primary is not allowed.
                        this.DeleteAndInsert(oldValue, dummy);

                        return true;
                    }

                    oldValue.UpdateValues(dummy);
                }
            }

            db.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Delete all of the objects for which this predicate holds.
        /// </summary>
        /// <param name="f">
        /// The predicate to select by (where).
        /// </param>
        /// <returns>
        /// True if the delete was successful, false otherwise.
        /// </returns>
        public bool Delete(Expression<Func<T, bool>> f)
        {
            var oldValues = this.Read(f);

            if (oldValues != null)
            {
                this.db.GetTable<T>().DeleteAllOnSubmit(oldValues);
            }

            db.SubmitChanges();

            return true;
        }

        /// <summary>
        /// <para>Update the primary key by first deleting the entry and 
        /// inserting a new one. Implementation of this method is left to
        /// child classes, since trying to build predicates using
        /// IDataObject.PrimaryKey yields an error.</para>
        /// <para>Most implementations will suffice by just implementing the 
        /// following two lines of code:
        /// <code>this.Delete(v => v.PrimaryKey == oldValue.PrimaryKey);
        /// this.Create(dummy);</code></para>
        /// </summary>
        /// <param name="oldValue">
        /// The old value to be deleted.
        /// </param>
        /// <param name="dummy">
        /// The dummy to be inserted.
        /// </param>
        protected abstract void DeleteAndInsert(T oldValue, T dummy);
    }
}