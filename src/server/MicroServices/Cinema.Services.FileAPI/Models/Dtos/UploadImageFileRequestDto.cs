﻿namespace Cinema.Services.FileAPI.Models.Dtos
{
    public class UploadImageFileRequestDto
    {
        public int RelationId { get; set; }
        public IFormFileCollection? FormFileCollection { get; set; }
    }
}
