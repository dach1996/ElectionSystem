using System;

using System.Runtime.Serialization;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Mensages genéricos de error
    /// </summary>
    [Serializable]
    public enum MessageCodesApi
    {
        /// <summary>
        /// Transacción exitosa
        /// </summary>
        [EnumMember(Value = "Requiere Token")]
        WithOutToken = 100,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Token Incorrecto")]
        InvalidToken = 101,

        /// <summary>
        /// Error parceo de Token
        /// </summary>
        [EnumMember(Value = "Error lectura de token")]
        InvalidParceToken = 102,

        /// <summary>
        /// Token Expirado
        /// </summary>
        [EnumMember(Value = "Token Expirado, Logee nuevamente")]
        TokenExpired = 103,

        /// <summary>
        /// Inconsistencia de datos
        /// </summary>
        [EnumMember(Value = "Servicio No Autorizado")]
        NotAuthorization = 112,

        /// <summary>
        /// Inconsistencia de datos
        /// </summary>
        [EnumMember(Value = "Error inconsistencia de datos")]
        DataInconsistency = 111,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Datos Incorrectos")]
        IncorrectData = 110,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Privilegios insuficientes")]
        InsufficientPrivileges = 125,

        /// <summary>
        /// Datos ya registrados
        /// </summary>
        [EnumMember(Value = "Datos ya registrados")]
        DataExist = 126,

        /// <summary>
        /// Datos no registrados al usuario Actual
        /// </summary>
        [EnumMember(Value = "Datos no registrados al usuario")]
        DataWithoutProperty = 127,

        /// <summary>
        /// Email ya se encuentra registrado
        /// </summary>
        [EnumMember(Value = "Email Registrado")]
        EmailRegistered = 128,

        /// <summary>
        /// Evento Registrado
        /// </summary>
        [EnumMember(Value = "Nombre de Evento ya registrado")]
        EventRegistered = 129,

        /// <summary>
        /// Error al Enviar Mail
        /// </summary>
        [EnumMember(Value = "No se pudo enviar el Mail")]
        MailError = 130,

        /// <summary>
        /// Erro usuario registrado en el Evento
        /// </summary>
        [EnumMember(Value = "Usuario ya registrado en Evento")]
        UserRegisterEvent = 131,

        /// <summary>
        /// Máximo de participantes excedido para el evento
        /// </summary>
        [EnumMember(Value = "El número de participantes ha usperado la cantidad permitida")]
        LimitMaxParticipants = 132,

        /// <summary>
        /// Usuario no es administrador del evento
        /// </summary>
        [EnumMember(Value = "El Usuario no es administrador del evento")]
        UserIsnotAdministratorEvent = 133,

        /// <summary>
        ///Candidato no se encuentra registrado
        /// </summary>
        [EnumMember(Value = "Candidato no está registrado al evento")]
        CandidateDontRegister = 134,

        /// <summary>
        /// Erro usuario registrado en el Evento
        /// </summary>
        [EnumMember(Value = "Usuario no registrado al evento")]
        UserNotRegisterEvent = 135,

        /// <summary>
        /// Usuario ya registra voto
        /// </summary>
        [EnumMember(Value = "El usuario ya ha participado en el evento")]
        UserHasVote = 136,

        /// <summary>
        /// Usuario ya registra voto
        /// </summary>
        [EnumMember(Value = "El usuario se encuentra registrado como candidato en el evento")]
        IsCandidateInEvent = 137,

        /// <summary>
        /// El código del evento es incorrecto
        /// </summary>
        [EnumMember(Value = "El código del evento es incorrecto")]
        IncorrectCodeEvent = 138,

        /// <summary>
        /// Requiere por lo menos envíar un Email
        /// </summary>
        [EnumMember(Value = "Email no válido")]
        InvalidEmail = 139,

        /// <summary>
        /// Error al guardar la imagen
        /// </summary>
        [EnumMember(Value = "Erro al guardar la imágen")]
        ErrorSaveImage = 140,

        /// <summary>
        /// Error al guardar la imagen
        /// </summary>
        [EnumMember(Value = "Error Máxima cantidad de imágenes permitidas")]
        MaxImageAllow = 141,

        /// <summary>
        /// No se encuentra archivo
        /// </summary>
        [EnumMember(Value = "No se encuentra recurso")]
        ResourceNotFound = 142,

        /// <summary>
        /// No se encuentra archivo
        /// </summary>
        [EnumMember(Value = "El candidato no pertence al evento")]
        CandidateDontExistInEvent = 144,

        /// <summary>
        /// Candidato está desactivado
        /// </summary>
        [EnumMember(Value = "El candidato se encuentra desactivado")]
        CandidateIsDesactive = 145,

        /// <summary>
        /// Participante está desactivado
        /// </summary>
        [EnumMember(Value = "El participante ya se encuentra desactivado")]
        ParticipantIsDesactive = 146,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Modelo de datos Invalido")]
        ModelInvalid = 150,
        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Usuario se encuntra desactivado")]
        UserIsInactive = 151,
        /// <summary>
        /// Evento Descativado
        /// </summary>
        [EnumMember(Value = "Evento se encuntra desactivado")]
        EventIsInactive = 152,
        /// <summary>
        /// Error maximos  evento permitidos
        /// </summary>
        [EnumMember(Value = "Ha superado el número de eventos permitidos para este usuario")]
        MaxEventAllow = 153,

        /// <summary>
        /// Error maximos  evento permitidos
        /// </summary>
        [EnumMember(Value = "El número maximo de personas para el evento no puede ser menor a 5")]
        MaxPeopleEvent = 154,

        /// <summary>
        /// Error maximos  evento permitidos
        /// </summary>
        [EnumMember(Value = "El usuario actual no es el creador de Evento")]
        EventCreator = 155,

        /// <summary>
        /// Error maximos  evento permitidos
        /// </summary>
        [EnumMember(Value = "El evento no permite registros libres")]
        EventNotAllowFreeRegister = 156,


        /// <summary>
        /// Error maximos  evento permitidos
        /// </summary>
        [EnumMember(Value = "Usuario no se encuentra autorizado para registrace por código el evento")]
        NotAllowRegisterByCode = 157,

        /// <summary>
        /// Fechas Incorrectas
        /// </summary>
        [EnumMember(Value = "Fechas incorrectas")]
        IncorrectDates = 158,

        /// <summary>
        /// Fechas Incorrectas
        /// </summary>
        [EnumMember(Value = "El usuario no pertene al candidato")]
        UserIsNotCandidate = 159,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo crear registro")]
        NotCreateRecord = 300,
        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo encontrar registro")]
        NotFindRecord = 301,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo Actualizar registro")]
        NotUpdateRecord = 302,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo Eliminar registro")]
        NotDeleteRecord = 303,

        /// <summary>
        /// Transacción exitosa
        /// </summary>
        [EnumMember(Value = "Error Inesperado")]
        ErrorGeneric = 600
    }
}
