#Loads env variables from the .env file into Python's os environment
from dotenv import load_dotenv

#Import the OpenAI client class - this is what makes API calls
from openai import OpenAI

# load the .env file into Python's os environment
load_dotenv(override=True)

#create the client - it autommactially reads OPENAI_API_KEY from the environment
client = OpenAI()

#Make the API call -- this is the actual HTTP POST to OpenAI's servers
response = client.chat.completions.create(
    model="gpt-4o-mini", # The model to use for the API call
    messages=[ #The messae list - this is the conversation you're sending 

    #one message to the user with a hardcoded prompt
    {"role": "user", "content": "Hello, how are you on this fine day?"}
    ]
)

# Navigate the response object to extrat just the tet reply
print(response.choices[0].message.content)