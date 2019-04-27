# imports the standard librayr sys and the third part library requests
import sys,requests
# imports the BeautifulSoup webscraping module 
from bs4 import BeautifulSoup

steam_price = None

# initiates the command line generated through the Webscraper class argument into a string
steam_url = sys.argv[1]
response = requests.get(steam_url)

# conditionals handle request status codes
if response.status_code == 200:
    soup = BeautifulSoup(response.content,"html.parser")
    div_element = soup.find("div",{"class":"game_purchase_price"})
    steam_price = div_element.text.strip()
    print(steam_price)
elif response.status_code == 403:
    print("forbidden")
elif response.status_code == 404:
    print("not found")