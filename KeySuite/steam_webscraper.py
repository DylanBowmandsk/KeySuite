import sys,requests
from bs4 import BeautifulSoup

keys_on_market = None
market_price = None

steam_url = sys.argv[1]
response = requests.get(steam_url)

if response.status_code == 200:
    soup = BeautifulSoup(response.content,"html.parser")
    div_element = soup.find("div",{"class":"game_purchase_price"})
    steam_price = div_element.text.strip()
    print(steam_price)
    
else:
    print("forbidden")
