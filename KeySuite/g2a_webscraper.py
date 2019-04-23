import sys,requests
from bs4 import BeautifulSoup

keys_on_market = None
market_price = None

g2a_url = sys.argv[1]
header = {'User-Agent': 'Mozilla/5.0'}
response = requests.get(g2a_url)

if response.status_code == 200:
    soup = BeautifulSoup(response.content,"html.parser")
    keys_div_element = soup.find("div",{"class":"product-offers__title"})
    keys_on_market = keys_div_element.find("h2").text.strip()

    price_list = soup.find("ul", {"class": "offers-list"})
    lowest_price = price_list[0].text.strip()
    print(keys_on_market)
    print(lowest_price)
else:
    print("forbidden")
