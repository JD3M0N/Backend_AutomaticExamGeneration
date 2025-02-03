using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;

        public ResponseService(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<IEnumerable<ResponseDto>> GetAllResponsesAsync()
        {
            var responses = await _responseRepository.GetAllResponsesAsync();
            return responses.Select(r => new ResponseDto
            {
                StudentId = r.StudentId,
                QuestionId = r.QuestionId,
                ExamId = r.ExamId,
                Answer = r.Answer
            });
        }

        public async Task<ResponseDto> GetResponseByIdAsync(int id)
        {
            var response = await _responseRepository.GetResponseByIdAsync(id);
            if (response == null) return null;

            return new ResponseDto
            {
                StudentId = response.StudentId,
                QuestionId = response.QuestionId,
                ExamId = response.ExamId,
                Answer = response.Answer
            };
        }

        public async Task AddResponseAsync(ResponseDto responseDto)
        {
            var response = new Response
            {
                StudentId = responseDto.StudentId,
                QuestionId = responseDto.QuestionId,
                ExamId = responseDto.ExamId,
                Answer = responseDto.Answer
            };

            await _responseRepository.AddResponseAsync(response);
        }

        public async Task UpdateResponseAsync(int id, ResponseDto responseDto)
        {
            var response = await _responseRepository.GetResponseByIdAsync(id);
            if (response != null)
            {
                response.StudentId = responseDto.StudentId;
                response.QuestionId = responseDto.QuestionId;
                response.ExamId = responseDto.ExamId;
                response.Answer = responseDto.Answer;

                await _responseRepository.UpdateResponseAsync(response);
            }
        }

        public async Task DeleteResponseAsync(int id)
        {
            await _responseRepository.DeleteResponseAsync(id);
        }

        public async Task<IEnumerable<ResponseDto>> GetResponsesByExamAndStudentAsync(int examId, int studentId)
        {
            var responses = await _responseRepository.GetResponsesByExamAndStudentAsync(examId, studentId);
            return responses.Select(r => new ResponseDto
            {
                StudentId = r.StudentId,
                QuestionId = r.QuestionId,
                ExamId = r.ExamId,
                Answer = r.Answer
            });
        }
    }
}
