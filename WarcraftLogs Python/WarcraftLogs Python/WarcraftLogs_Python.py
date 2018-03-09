import json, requests

# Warcraft Logs Public API Key
# d61ae7109219494d4b032246eec72339
params = { 'api_key': 'd61ae7109219494d4b032246eec72339' }

def getLogRankingsByID(encounterID):
    # Gathers the rankings by Encounter ID (found by calling getEncounterIDs())
    url = 'https://www.warcraftlogs.com/v1/rankings/encounter/' + encounterID
    response = requests.post(url, params=params)

    return response.json()

def getCharacterRanking(charName, serverName, region):
    #Gathers the rankings for specified character
    url = 'https://www.warcraftlogs.com/v1/rankings/character/' + charName + '/' + serverName + '/' + region
    response = requests.post(url, params=params)

    return response.json()

def getEncounterIDs():
    # Gathers the Encounters and their associated IDs
    response = requests.post('https://warcraftlogs.com/v1/zones', params=params)
    
    return response.json()

def getCharacterParses(charname, serverName, region):
    #Gathers the parses for the specified character
    url = 'https://www.warcraftlogs.com/v1/parses/character/' + charName + '/' + serverName + '/' + region
    response = requests.post()

if __name__ == "__main__":
    app.run()