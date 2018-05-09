
import MySQLdb
import plotly.offline as offline
conn = MySQLdb.connect(host="SERVERNAME", user="USERNAME", passwd="PASSWORD", db="DBNAME")
offline.init_notebook_mode()

cursor = conn.cursor()
cursor.execute('select ID,breaks,discussions,goodMornings,tasksCompleted from professional');
rows = cursor.fetchall()

import pandas as pd
df = pd.DataFrame( [[ij for ij in i] for i in rows] )
df.rename(columns={0: 'tasksCompleted', 1: 'breaks', 2:'ID',3:'goodMornings',4:'discussions'}, inplace=True);
df = df.sort_values(['ID'], ascending=[1]);
df2 = df.sort_values(['ID'], ascending=[1]);
df3 = df.sort_values(['ID'], ascending=[1]);

import plotly.plotly as py
from plotly.graph_objs import *
 
tasks = Scatter(
     x=df['ID'],
     y=df['breaks'],
     mode='lines',
     name='breaks'
)
tasks2 = Scatter(
     x=df2['ID'],
     y=df2['tasksCompleted'],
     mode='lines',
     name='tasksCompleted'
)
tasks3 = Scatter(
     x=df3['ID'],
     y=df3['discussions'],
     mode='markers+lines',
     name='discussions'
)

layout = Layout(
     xaxis=XAxis( title='time' ),
     yaxis=YAxis( type='log', title='action' )
)

data = Data([tasks, tasks2, tasks3])
fig = Figure(data=data, layout=layout)
offline.iplot(fig, filename='graph', image='png')


#py.image.save_as(fig, filename='/var/www/html/graph.png')

#from IPython.display import image
#Image('/var/www/html/graph.png')

#offline.plot([Scatter(x=[1,2,3],y=[1,4,2])])

