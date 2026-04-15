# p1_hello_llm.R

library(dotenv)
dotenv::load_dot_env(file = ".env")  # no override argument in your dotenv

api_key <- Sys.getenv("OPENAI_API_KEY")
if (api_key == "") stop("OPENAI_API_KEY is not set. Put it in .env (or set an env var).")

prompt <- "Hello, how are you on this fine day?"
body <- list(
  model = "gpt-4o-mini",
  messages = list(
    list(role = "user", content = prompt)
  )
)

library(httr2)
library(jsonlite)

req <- request("https://api.openai.com/v1/chat/completions") |>
  req_headers(
    Authorization = paste("Bearer", api_key),
    `Content-Type` = "application/json"
  ) |>
  req_body_json(body)

resp <- req_perform(req)

status <- resp_status(resp)
text <- resp_body_string(resp)

if (status < 200 || status >= 300) {
  stop(sprintf("OpenAI API request failed (HTTP %s):\n%s", status, text))
}

json <- fromJSON(text, simplifyVector = FALSE)

assistant_text <- json$choices[[1]]$message$content
cat(assistant_text, "\n")