namespace Dach.ElectionSystem.Models.Mail
{
    /// <summary>
    /// Modelo para Mail
    /// </summary>
    public class MailModel
    {
        /// <summary>
        /// De
        /// </summary>
        /// <value></value>
        public string From { get; set; }

        /// <summary>
        /// Asunto
        /// </summary>
        /// <value></value>
        public string Subject { get; set; }

        /// <summary>
        /// Para
        /// </summary>
        /// <value></value>
        public string To { get; set; }

        /// <summary>
        /// TemplateId
        /// </summary>
        /// <value></value>
        public string Template { get; set; }

        /// <summary>
        /// Parámetros
        /// </summary>
        /// <value></value>
        public object Params { get; set; }
    }
}