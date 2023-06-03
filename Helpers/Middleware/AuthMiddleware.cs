using proiectDAW.Helpers.Jwt;

namespace proiectDAW.Helpers.Middleware {
    public class AuthMiddleware {
        private readonly RequestDelegate _next;
        public AuthMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils) {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty) {
                context.Items["userId"] = userId;
            }
            System.Console.WriteLine("AuthMiddleware");
            await _next(context);
        }
    }
}