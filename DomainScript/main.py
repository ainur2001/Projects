import whois
import nmap
import dns.resolver
import socket

# задаем домен компании
domain = "google.com"

# получаем информацию о домене с помощью whois
w = whois.whois(domain)

# выводим информацию о владельце домена
print("Owner: ", w.name)

# получаем ip-адрес домена
ip = socket.gethostbyname(domain)
print("IP Address: ", ip)

# выполняем reverse DNS запрос для получения имени хоста
hostname = socket.gethostbyaddr(ip)[0]
print("Hostname: ", hostname)

# используем nmap для сканирования портов на хосте
nm = nmap.PortScanner()
nm.scan(ip)

# выводим открытые порты
print("Open Ports: ", nm[ip]['tcp'].keys())

# получаем MX записи для домена
mx_records = dns.resolver.query(domain, 'MX')
mx_list = [str(record.exchange)[:-1] for record in mx_records]
print("MX Records: ", mx_list)

# получаем NS записи для домена
ns_records = dns.resolver.query(domain, 'NS')
ns_list = [str(record) for record in ns_records]
print("NS Records: ", ns_list)

# получаем SOA запись для домена
soa_record = dns.resolver.query(domain, 'SOA')
soa_str = str(soa_record[0])
soa_list = soa_str.split(' ')
print("SOA Records: ", soa_list)

# выводим список поддоменов
for subdomain in nm.all_hosts():
    if subdomain.endswith(domain):
        print("Subdomain: ", subdomain)
