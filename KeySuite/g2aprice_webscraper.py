import sys,requests
from bs4 import BeautifulSoup

keys_on_market = None
market_price = None

g2a_url = sys.argv[1]
header = {'User-Agent': 'Mozilla/5.0'}
response = requests.get(g2a_url)

if response.status_code == 200:
    soup = BeautifulSoup(response.content,"html.parser")

    price_list = soup.find("ul", {"class": "offers-list"})
    lowest_price = price_list[0].text.strip()

    print(market_price)
else:
    print("forbidden")