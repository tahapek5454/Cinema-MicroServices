
namespace SharedLibrary.Settings
{
    public static class RabbitMQSettings
    {
        public const string FileStateMachineQueue = "file_state_machine_queue";
        public const string Movie_MovieImageUploadedQueue = "movie_movie_image_uploaded_event_queue";
        public const string File_MovieImageRollbackMessageQueue = "file_movie_image_rollback_message_queue";

    }
}
