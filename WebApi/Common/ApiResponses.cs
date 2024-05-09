using Domain.Models.DTOs;

namespace WebApi.Common
{
    public static class ApiResponses
    {
        public static CommonResponse<T> Ok<T>(T? objResponse)
        {
            return Response(objResponse, true, null);
        }

        public static CommonResponse<T> CreateKO<T>(T objResponse, IEnumerable<string> errors)
        {
            return Response(objResponse, false, errors);
        }

        private static CommonResponse<T> Response<T>(T? objResponse, bool success, IEnumerable<string>? errors)
        {
            return new CommonResponse<T>()
            {
                Data = objResponse,
                Errors = errors,
                Success = success,
            };
        }
    }
}
