using FileContent.CustomAttribute;

namespace FileContent.Interface
{
    public interface IDocs
    {
        [Description("An interface for displaying list of users in the list.")]
        void DisplayUser();
    }
}
