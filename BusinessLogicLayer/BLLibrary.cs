using AutoMapper;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLibrary
    {
        private readonly ResponseContextDB _context;
        private readonly IMapper _mapper;

        public BLLibrary(ResponseContextDB context)
        {
            _context = context;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Response, ResponseBLL>().ReverseMap();
                cfg.CreateMap<ResponseAnswer, ResponseAnswerBLL>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        // CRUD operations for Response

        public ResponseBLL CreateResponse(ResponseBLL responseBLL)
        {
            var responseEntity = _mapper.Map<Response>(responseBLL);
            _context.Responses.Add(responseEntity);
            _context.SaveChanges();
            return _mapper.Map<ResponseBLL>(responseEntity);
        }

        public ResponseBLL GetResponse(int id)
        {
            var responseEntity = _context.Responses.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<ResponseBLL>(responseEntity);
        }

        public IEnumerable<ResponseBLL> GetAllResponses()
        {
            var responseEntities = _context.Responses.ToList();
            return _mapper.Map<IEnumerable<ResponseBLL>>(responseEntities);
        }

        public void UpdateResponse(ResponseBLL responseBLL)
        {
            var responseEntity = _mapper.Map<Response>(responseBLL);
            _context.Responses.Update(responseEntity);
            _context.SaveChanges();
        }

        public void DeleteResponse(int id)
        {
            var responseEntity = _context.Responses.FirstOrDefault(r => r.Id == id);
            if (responseEntity != null)
            {
                _context.Responses.Remove(responseEntity);
                _context.SaveChanges();
            }
        }

        // CRUD operations for ResponseAnswer

        public ResponseAnswerBLL CreateResponseAnswer(ResponseAnswerBLL responseAnswerBLL)
        {
            var responseAnswerEntity = _mapper.Map<ResponseAnswer>(responseAnswerBLL);
            _context.ResponseAnswers.Add(responseAnswerEntity);
            _context.SaveChanges();
            return _mapper.Map<ResponseAnswerBLL>(responseAnswerEntity);
        }

        public ResponseAnswerBLL GetResponseAnswer(int id)
        {
            var responseAnswerEntity = _context.ResponseAnswers.FirstOrDefault(ra => ra.ResponseId == id);
            return _mapper.Map<ResponseAnswerBLL>(responseAnswerEntity);
        }

        public IEnumerable<ResponseAnswerBLL> GetAllResponseAnswers()
        {
            var responseAnswerEntities = _context.ResponseAnswers.ToList();
            return _mapper.Map<IEnumerable<ResponseAnswerBLL>>(responseAnswerEntities);
        }

        public void UpdateResponseAnswer(ResponseAnswerBLL responseAnswerBLL)
        {
            var responseAnswerEntity = _mapper.Map<ResponseAnswer>(responseAnswerBLL);
            _context.ResponseAnswers.Update(responseAnswerEntity);
            _context.SaveChanges();
        }

        public void DeleteResponseAnswer(int id)
        {
            var responseAnswerEntity = _context.ResponseAnswers.FirstOrDefault(ra => ra.ResponseId == id);
            if (responseAnswerEntity != null)
            {
                _context.ResponseAnswers.Remove(responseAnswerEntity);
                _context.SaveChanges();
            }
        }
        public IEnumerable<ResponseWithAnswersDTO> GetResponsesWithAnswers()
        {
            var reponses = from ra in _context.ResponseAnswers
                           join r in _context.Responses on ra.ResponseId equals r.Id
                           group new { ra, r } by new { r.Id, r.QuizId, r.UserId } into groupbyresponse
                           select new ResponseWithAnswersDTO
                           {
                               Id = groupbyresponse.Key.Id,
                               UserId = groupbyresponse.Key.UserId,
                               QuizId = groupbyresponse.Key.QuizId,
                               Answers = groupbyresponse.Select(required => new AnswerDTO
                               {
                                   QuestionId = required.ra.QuestionId,
                                   AnswerText = required.ra.AnswerText
                               }).ToList(),
                           };
            return reponses;
        }
    }
}
