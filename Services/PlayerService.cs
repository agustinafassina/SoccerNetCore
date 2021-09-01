using System;
using System.Collections.Generic;
using System.IO;
using SoccerNetCore.Models;
using SoccerNetCore.Repository;

namespace SoccerNetCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ISendEmailService _sendEmailService;
        private readonly ITeamRepository _teamRepository;
        public PlayerService(IPlayerRepository playerRepository, ISendEmailService sendEmailService, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _sendEmailService = sendEmailService;
        }

        public List<Player> GetList()
        {
            return (List<Player>)_playerRepository.ListAll();
        }

        public Player Get(int PlayerId)
        {
            return _playerRepository.GetById(PlayerId);
        }

        public void Post(Player request, Stream file)
        {
            request.LogoNameUniq = SaveLogo(file, request.Logo);
            _playerRepository.Add(request);
        }

        private string SaveLogo(Stream fileLogo, string logoName)
        {
            //save file logo/ Rename: name + now + extension.
            var fileExtension = Path.GetExtension(logoName);
            var fileName = Path.GetFileNameWithoutExtension(logoName);
            //This is to avoid repeating the file name.
            var now = Convert.ToString((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            var fileNameNow = fileName + "-" + now + fileExtension;
            //My path in windows is C:\Users\User\AppData\Local\Temp
            var tmpFileName = Path.Combine(Path.GetTempPath(), fileNameNow);

            fileLogo.Seek(0, SeekOrigin.Begin);
            byte[] result = new byte[fileLogo.Length];
            fileLogo.Read(result, 0, result.Length);

            File.WriteAllBytes(tmpFileName, result);

            return fileNameNow;
        }

        public void Delete(int playerId)
        {
            Player player = _playerRepository.GetById(playerId);
            _playerRepository.Remove(player);
        }

        public void Update(int playerId, Player body)
        {
            if(_playerRepository.GetById(playerId).Id > 0)
            {
                _playerRepository.Update(body, playerId);
            }
        }

        public void GetSendEmail(int PlayerId)
        {
            var player = _playerRepository.GetById(PlayerId);
            var team = _teamRepository.GetById(player.TeamId);
            //_sendEmailService.SendEmail(player, team.Name);
            _sendEmailService.SendEmailForMailkit(player, team.Name);
        }
    }
}