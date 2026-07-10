using TutorTrackerDatabase;

namespace TutorTrackerModel;

public class Models
{
    public static void Save<T>(IModel<T> model) where T : IModel<T>
    {
        model.Save();
    }

    public static void Delete<T>(IModel<T> model) where T : IModel<T>
    {
        model.Delete();
    }
}