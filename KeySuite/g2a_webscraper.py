import sys,requests
from bs4 import BeautifulSoup

keys_on_market = None
market_price = None

g2a_url = sys.argv[1]
header = {'User-Agent': 'Mozilla/5.0'}
response = requests.get(g2a_url)

if response.status_code == 200:
    print("good")
else:
    print("forbidden")
