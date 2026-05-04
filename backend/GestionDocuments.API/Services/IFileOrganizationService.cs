using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionDocuments.API.Services
{
    /// <summary>
    /// Interface pour l'organisation des fichiers par Service et Citoyen
    /// Permet de classer les fichiers dans une arborescence :
    /// uploads/Services/{ServiceNom}/{CitoyenIdentity}/fichiers...
    /// 
    /// L'identité unique du citoyen est déterminée par : Nom + Email + ServiceId
    /// Si l'un de ces éléments diffère, le citoyen va dans un dossier différent
    /// </summary>
    public interface IFileOrganizationService
    {
        /// <summary>
        /// Organise un fichier dans l'arborescence par Service > Citoyen
        /// </summary>
        Task<string> OrganizeFileAsync(string nomCitoyen, string emailCitoyen, int serviceId, string cheminFichierSource);

        /// <summary>
        /// Récupère le chemin organisé pour un citoyen donné
        /// </summary>
        string GetCitizenFolderPath(string nomCitoyen, string emailCitoyen, int serviceId);

        /// <summary>
        /// Récupère le chemin du service
        /// </summary>
        string GetServiceFolderPath(int serviceId);

        /// <summary>
        /// Supprime le dossier d'un citoyen et tous ses fichiers
        /// </summary>
        Task DeleteCitizenFolderAsync(string nomCitoyen, string emailCitoyen, int serviceId);

        /// <summary>
        /// Obtient la liste des fichiers pour un citoyen
        /// </summary>
        Task<List<string>> GetCitizenFilesAsync(string nomCitoyen, string emailCitoyen, int serviceId);

        /// <summary>
        /// Génère un identifiant unique pour le citoyen (hash de nom+email+serviceId)
        /// </summary>
        string GenerateCitizenIdentity(string nomCitoyen, string emailCitoyen, int serviceId);
    }
}