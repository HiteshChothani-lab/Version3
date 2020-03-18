﻿namespace UserManagement.WebServices.DataContracts.Request
{
    public class UpdateButtonsRequestContract
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public long UserId { get; set; }
        public string Button1 { get; set; }
        public string Button2 { get; set; }
        public string Button3 { get; set; }
        public string ButtonAB { get; set; }
        public string Note { get; set; }
        public string NoteColor { get; set; }
        public long SuperMasterId { get; set; }
    }
}
