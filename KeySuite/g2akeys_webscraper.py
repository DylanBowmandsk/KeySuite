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
    keys_div_element = soup.find("div",{"class":"product-offers__title"})
    keys_on_market = keys_div_element.find("h2").text.strip()
    print(keys_on_market)
elif response.status_code == 403:
    print("forbidden")
elif response.status_code == 404:
    print("not found")


