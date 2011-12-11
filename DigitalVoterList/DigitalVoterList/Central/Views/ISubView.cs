// -----------------------------------------------------------------------
// <copyright file="ISubView.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Views
{
    using DigitalVoterList.Central.Models;

    /// <summary>
    /// Marker interface for sub-views.
    /// </summary>
    public interface ISubView
    {
        ISubModel GetModel();
    }
}
