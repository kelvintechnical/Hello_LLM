# Project Roadmap: Foundations → Agents SDK → LangGraph

This document is a cleaned-up, long-form version of my full project idea list. It’s organized as three tracks, each building on the previous one.

## 🔵 Foundations Lab On-Ramp (15 projects)

Goal: learn the request/response lifecycle, then add memory, tools, UIs, and deployment.

1. **Hello, LLM** — Call the OpenAI API with a hardcoded message and print the response.
2. **Persona Bot (single turn)** — Add a system prompt that makes the model act as a specific person.
3. **Chatbot with Memory** — Add a loop that grows the `messages` list on each turn.
4. **Context from a File** — Read a `.txt` file and inject its contents into the system prompt.
5. **PDF Reader Bot** — Replace the `.txt` file with a PDF using `pypdf`.
6. **Add a Gradio UI** — Wrap the memory chatbot in `gr.ChatInterface` and launch it locally.
7. **Your First Tool (one function)** — Define a single JSON tool schema and handle the `tool_calls` branch.
8. **Multi-Tool if/elif Router** — Add a second tool and build `handle_tool_calls()` using `if/elif`.
9. **Elegant Tool Router (no if/elif)** — Refactor the router using `globals().get(tool_name)`.
10. **Pushover + Lead Capture Bot** — Wire up Pushover and add `record_user_details` and `record_unknown_question` as tools.
11. **The While Loop (no tools)** — Build the `while not done` loop as a standalone `loop()` function.
12. **Loop + One Action Tool** — Add one tool back into the loop and give the agent a real task.
13. **Multi-step Task Agent** — Give the agent a multi-step problem using `create_todos` and `mark_complete`.
14. **Agent + Gradio UI** — Combine the agentic loop with the Gradio interface.
15. **Deploy to Hugging Face Spaces** — Run `gradio deploy` and get a live URL.

## 🟡 OpenAI Agents SDK (30 projects)

Goal: learn the Agents SDK primitives (agents, tools, handoffs, tracing, streaming), then build multi-agent pipelines with structured outputs and guardrails.

1. **Hello, Agents SDK** — Create a single Agent, run it with `Runner.run`, and print `final_output`.
2. **Wrap it in a Trace** — Add `with trace()` and verify it in the OpenAI Traces UI.
3. **Streaming Output** — Switch to `Runner.run_streamed` and loop over `stream_events`.
4. **Three Agents, Same Task** — Create three agents with different personalities and run them one at a time.
5. **Parallel Agents with `asyncio.gather`** — Run all three agents simultaneously.
6. **Picker Agent** — Add a fourth agent that reads the three outputs and picks the best one.
7. **Your First `@function_tool`** — Decorate a plain Python function with `@function_tool`.
8. **Agent as a Tool (`.as_tool`)** — Call `agent.as_tool()` and pass it into another agent’s `tools` list.
9. **Handoff vs Tool** — Pass an agent via `handoffs=` and compare traces to using `tools=`.
10. **Sales Manager (full Lab 2 workflow)** — Combine everything into a working multi-agent sales pipeline.
11. **Swap One Agent to Gemini** — Wire up `AsyncOpenAI` with the Gemini base URL and a Gemini model object.
12. **Three Agents, Three Models** — Add DeepSeek and Groq/Llama alongside Gemini.
13. **Structured Output with Pydantic (simple)** — Pass `output_type=` to an agent and access typed fields.
14. **Structured Output with Field descriptions** — Add `Field(description=...)` to shape model output.
15. **Guardrail Agent** — Create a structured-output agent with a boolean field as a tripwire.
16. **`@input_guardrail` decorator** — Wrap the guardrail in `@input_guardrail` and return `GuardrailFunctionOutput`.
17. **Test the guardrail (pass and fail)** — Run two inputs and validate the control flow.
18. **Reconnect multi-model agents + guardrail** — Integrate models, structured output, and guardrails end-to-end.
19. **Add `model_settings` (tool_choice)** — Add `ModelSettings(tool_choice="required")` to force tool use.
20. **Full Lab 3 pipeline (guarded SDR)** — Complete a guarded, formatted, HTML email pipeline.
21. **WebSearchTool (one search agent)** — Create a search agent using the hosted `WebSearchTool`.
22. **Planner agent with structured output** — Build `WebSearchItem` and `WebSearchPlan` Pydantic models.
23. **`plan_searches` + `search()` async functions** — Wire the planner output into parallel search execution.
24. **Writer agent with `ReportData` output** — Create a `ReportData` model and a synthesis writer agent.
25. **`email_agent` (report → formatted email)** — Build an email agent that converts a Markdown report to an HTML email.
26. **`write_report` + `send_email` async functions** — Wrap writer and emailer agents in async functions.
27. **Showtime (full pipeline run)** — Chain everything inside one trace block and receive the email.
28. **Tune it (search count + cost control)** — Change `HOW_MANY_SEARCHES` and observe cost vs quality.
29. **Personalize for your domain** — Swap the query to a bioinformatics topic or Mimikry competitor analysis.
30. **Read Labs 1–4 independently** — Read every lab cell and explain every line without help.

## 🟢 LangGraph (30 projects)

Goal: learn graph-based agent control flow: state, nodes, edges, tool loops, conditional routing, memory, evaluation loops, async execution, and UI integration.

1. **Print “hello” through a graph node** — Build the 5-step skeleton with `TypedDict` state and no LLM.
2. **Two nodes in sequence** — Add a second node and confirm data flows through both.
3. **The `messages` field + `add_messages` reducer** — Switch to an `Annotated` list and observe accumulation.
4. **Draw the graph** — Add `draw_mermaid_png` after `compile()` and visualize the structure.
5. **Plug in an LLM node** — Replace the hardcoded node with a real `ChatOpenAI` call.
6. **Wrap in Gradio and feel the missing memory** — Launch `ChatInterface` and notice stateless resets.
7. **Create one LangChain tool (Pushover)** — Wrap the Pushover function in a `Tool` object and invoke it directly.
8. **`bind_tools` + ToolNode (draw the shape)** — Add `ToolNode` and static loop edges, then draw it.
9. **Conditional edge with `tools_condition`** — Replace the static edge with `add_conditional_edges`.
10. **MemorySaver (persistent memory)** — Add a checkpointer and a `thread_id` config.
11. **SqliteSaver (durable memory)** — Swap MemorySaver for SqliteSaver using a `memory.db` file.
12. **Add a second tool (multi-tool agent)** — Add GoogleSerper and combine both tools.
13. **Convert `graph.invoke` to async** — Switch to `ainvoke` and `async def chat`.
14. **Open a browser with Playwright (no graph yet)** — Test `navigate` and `extract_text` standalone.
15. **List and explore all Playwright tools** — Loop over `toolkit.get_tools()` and call them manually.
16. **Plug Playwright tools into the async graph** — Combine all tools and rebuild the async graph.
17. **Give it a multi-step browser task** — Ask it to navigate and push results via Pushover.
18. **Async Gradio UI (Lab 3 complete)** — Wrap the async graph in Gradio and launch.
19. **State with multiple fields beyond messages** — Design a `TypedDict` with `task`, `feedback`, `is_done`, and `needs_user`.
20. **Structured output with `.with_structured_output()`** — Create a Pydantic model and bind it to a second LLM.
21. **A node that builds its system prompt from state** — Write a worker node with a dynamic system message.
22. **An evaluator node that writes back to state** — Write an evaluator that updates control fields in state.
23. **Write a custom router function** — Write `route_after_eval()` as plain Python `if/else`.
24. **Wire the dual-loop graph and draw it** — Assemble the tool loop and eval loop, then draw it.
25. **Success criteria as a UI input (`gr.Blocks`)** — Build a Gradio Blocks UI with two text inputs.
26. **UUID `thread_id` + Reset button** — Add UUID generation and a Reset handler.
27. **Test the eval loop: deliberate pass and retry** — Give strict criteria and watch the loop in LangSmith.
28. **Extract into a Sidekick class** — Move graph logic into a class with `setup`, `run_superstep`, and `cleanup`.
29. **Write `app.py` (thin Gradio shell)** — Write the final `app.py` with `ui.load` and `delete_callback`.
30. **Read Labs 1–4 independently** — Read every lab cell and explain every line without help.

