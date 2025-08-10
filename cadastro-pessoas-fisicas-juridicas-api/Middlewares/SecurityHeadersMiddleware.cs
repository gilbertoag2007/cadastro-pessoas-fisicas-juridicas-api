namespace cadastro_pessoas_fisicas_juridicas_api.Middlewares
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Headers mínimos de segurança comuns
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-Frame-Options"] = "DENY";
            context.Response.Headers["Referrer-Policy"] = "no-referrer";
            context.Response.Headers["Permissions-Policy"] = "geolocation=(), microphone=()";
            context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains; preload";

            // CSP customizado: mais relaxado para Swagger, mais restrito para o resto
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                // CSP para Swagger UI funcionar
                context.Response.Headers["Content-Security-Policy"] =
                    "default-src 'self'; " +
                    "script-src 'self' 'unsafe-inline' 'unsafe-eval' cdnjs.cloudflare.com; " +
                    "style-src 'self' 'unsafe-inline' cdnjs.cloudflare.com fonts.googleapis.com; " +
                    "font-src 'self' fonts.gstatic.com; " +
                    "img-src 'self' data:; " +
                    "connect-src 'self'; " +
                    "frame-ancestors 'none'; " +
                    "base-uri 'self'; " +
                    "form-action 'self';";
            }
            else
            {
                // CSP mais restrito para as outras rotas da API
                context.Response.Headers["Content-Security-Policy"] =
                    "default-src 'self'; " +
                    "frame-ancestors 'none'; " +
                    "base-uri 'self'; " +
                    "form-action 'self';";
            }

            await _next(context);
        }


    }
}
