# Hello_LLM (Python + C#)

A small “hello world” project that calls an OpenAI chat model from **two languages**—Python and C#—to learn the same concept from two angles: **how to authenticate, structure a request, send it, and read the response**.

I built this as a hands-on way to understand the LLM API lifecycle (inputs → API call → outputs), and to compare how different ecosystems solve the same problems (dependency management, secrets, async, and SDK ergonomics).

## What this project does

- **Python** (`python/p1_hello_llm.py`): loads an API key from `.env`, calls the Chat Completions API, prints the assistant’s reply.
- **C#** (`csharp/p1_hello_llm/Program.cs`): loads an API key from **.NET User Secrets**, calls the OpenAI Chat client asynchronously, prints the reply.

Both programs send the same prompt:

> “Hello, how are you on this fine day?”

## Why I did it (and why in two languages)

- **Transferable understanding**: If I can do the same LLM call in Python and C#, I’m not memorizing syntax—I’m learning the underlying “shape” of the system.
- **Ecosystem fluency**: Python is fast for iteration; C# is common in enterprise environments. Knowing both expands where I can apply LLM integrations.
- **Practical engineering habits**: secrets handling, dependency management, and reproducible runs are as important as “it works once on my machine.”

## Diesel-tech analogies (how it clicked for me)

Thinking in diesel terms helped me map new software concepts to something physical and familiar:

- **API key = authorized fuel source**
  - If the key is missing, it’s like trying to run a high-pressure common-rail system with no clean fuel supply: nothing downstream matters until supply is correct.
- **Client object = injection pump / rail controller**
  - The SDK client is the component that *knows how* to build pressure (HTTP request), meter it (parameters/model), and deliver it reliably.
- **Messages = injector command / timing map**
  - The prompt is your “command”: when you change it, you change what the engine does. Same hardware, different behavior.
- **Response parsing = reading the gauges**
  - The model returns a structured object; pulling out the actual text is like checking the right sensor PID instead of guessing from noise.
- **Async in C# = not blocking the whole shop**
  - The call is “waiting on parts delivery.” `await` lets other work continue instead of shutting down the whole bay until the truck arrives.

## What I learned (skills gained)

- **The request/response lifecycle**: model selection, message formatting, and navigating structured responses.
- **Secrets management trade-offs**:
  - Python: `.env` is convenient for local dev.
  - C#: User Secrets keep credentials out of the repo while still being easy to use on Windows.
- **SDK differences** without changing the underlying concept:
  - Python call style is straightforward and synchronous by default.
  - C# is async-first and strongly typed, which helps scale beyond “hello world.”

## Repo structure

```text
Hello_LLM/
  python/
    p1_hello_llm.py
  csharp/
    p1_hello_llm/
      Program.cs
      p1_hello_llm.csproj
  pyproject.toml
  .gitignore
```

## Setup

### 1) Get an API key

You’ll need an `OPENAI_API_KEY`.

Important: **Never commit secrets**. This repo’s `.gitignore` excludes `.env`.

### 2) Python run

Create a `.env` file in the repo root:

```bash
OPENAI_API_KEY=your_key_here
```

If you’re using `uv`:

```bash
uv sync
uv run python python/p1_hello_llm.py
```

Or with `pip`:

```bash
python -m venv .venv
.\.venv\Scripts\activate
pip install -r requirements.txt  # (or install from pyproject with your preferred tool)
python python/p1_hello_llm.py
```

### 3) C# run

Set the secret for the C# project:

```bash
dotnet user-secrets set "OPENAI_API_KEY" "your_key_here" --project csharp/p1_hello_llm
```

Run the console app:

```bash
dotnet run --project csharp/p1_hello_llm
```

## Notes on security

- **Do not store real keys in code**.
- Keep keys in **User Secrets** (C#) or `.env` (Python) locally.
- If a key is ever committed, treat it like contaminated fuel: **assume it’s compromised** and rotate it.

## Next steps (ideas)

- Add a tiny CLI to change the prompt at runtime.
- Add streaming output to see tokens arrive incrementally.
- Compare “same prompt” behavior across multiple models and log latency/cost.

