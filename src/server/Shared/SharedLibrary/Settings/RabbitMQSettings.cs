
namespace SharedLibrary.Settings
{
    public static class RabbitMQSettings
    {
        // file queue
        public const string FileStateMachineQueue = "file_state_machine_queue";
        public const string Movie_MovieImageUploadedQueue = "movie_movie_image_uploaded_event_queue";
        public const string Movie_MovieImageDeletedQueue = "movie_movie_image_deleted_event_queue";
        public const string File_MovieImageRollbackMessageQueue = "file_movie_image_rollback_message_queue";

        // reservation queue
        public const string ReservationStateMachineQueue = "reservation_state_machine_queue";
        public const string Session_ReservedQueue = "session_reserved_queue";
        public const string Reservation_ReservationRollbackMessageQueue = "reservation_reservation_rollback_message_queue";

        // Movie Change Queue
        public const string MovieChangeStateMachineQueue = "movie_change_state_machine_queue";
        public const string Category_MovieChangeQueue = "category_movie_change_queue";
        public const string File_MovieChangeQueue = "file_movie_change_queue";

    }
}
