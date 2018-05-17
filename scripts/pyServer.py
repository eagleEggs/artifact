import os
import matplotlib as mpl
if os.environ.get('DISPLAY','') == '':
    print('no display found. Using non-interactive Agg backend')
    mpl.use('Agg')
import matplotlib.pyplot as plt
import cgi
import matplotlib.pyplot as plt
import pandas
import MySQLdb
import pylab
import sys
import json
import string

cgi.test()
fn = "table.txt"
def FileCheck(fn):
    try:
      open(fn, "r")
      return 1
    except IOError:
      print "Error: File does not appear to exist."
      return 0

result = FileCheck("table.txt")
if (result == 1):

        try:
                file = open("table.txt")
                tableVar = file.readlines()
                file.close()
        except:
                print "issue"

tb = ''.join(tableVar)

try:
        file2 = open("column.txt")
        columnVar = file2.readlines()
        file2.close()
except:
        print "issue2"

co = ''.join(columnVar)

conn = MySQLdb.connect(host="HOST", user="UN", passwd="PW", db="DB")

query = 'SELECT breaks, {} FROM {}'.format(co,tb)
print query

df = pandas.read_sql(query, conn, index_col=['discussions'])
fig, ax = plt.subplots()
df.plot(ax=ax)
pylab.savefig('plot.png')
conn.close()
