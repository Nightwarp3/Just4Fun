import json, requests

# Warcraft Logs Public API Key
# d61ae7109219494d4b032246eec72339
params = { 'api_key': 'd61ae7109219494d4b032246eec72339' }
baseUrl = 'https://www.warcraftlogs.com:443/v1'

def getLogRankingsByID(encounterID):
    # Gathers the rankings by Encounter ID (found by calling getEncounterIDs())
    url = baseUrl + '/rankings/encounter/' + encounterID
    response = requests.post(url, params=params)

    return response.json()

def getCharacterRanking(charName, serverName, region):
    # Gathers the rankings for specified character
    url = baseUrl + '/rankings/character/' + charName + '/' + serverName + '/' + region
    response = requests.post(url, params=params)

    return response.json()

def getEncounterIDs():
    # Gathers the Encounters and their associated IDs
    response = requests.post(baseUrl + '/zones', params=params)
    
    return response.json()

def getCharacterParses(charname, serverName, region):
    # Gathers the parses for the specified character
    url = baseUrl + '/parses/character/' + charName + '/' + serverName + '/' + region
    response = requests.post(url, params=params)

def getGuildReports(guildName, serverName, region):
    # Gathers the uploaded reports by Guild
    url = baseUrl + '/reports/guild/' + guildName + '/' + serverName + '/' + region
    response = requests.post(url, params=params)

def getUsersReports(userName):
    url = baseUrl + '/reports/user/' + userName
    response = requests.post(url, params=params)