# imports the standard librayr sys and the third part library requests
import sys,requests
# imports the BeautifulSoup webscraping module 
from bs4 import BeautifulSoup

keys_on_market = None
market_price = None

# initiates the command line generated through the Webscraper class argument into a string
g2a_url = sys.argv[1]
header = {'User-Agent': 'Mozilla/5.0'}
response = requests.get(g2a_url)

# conditionals handle request status codes
if response.status_code == 200:
    soup = BeautifulSoup(response.content,"html.parser")
    price_list = soup.find("ul", {"class": "offers-list"})
    lowest_price = price_list[0].text.strip()
    print(market_price)
elif response.status_code == 403:
    print("forbidden")
elif response.status_code == 404:
    print("not found")