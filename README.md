# fc_2020
# README #

Hi everyone, thanks for taking the time to review this exercise.

I've broken my changes into two categories , business/flow changes and technical changes. I have attempted to document here the reasons for my changes and my intent in making said changes.
If anything is unclear please let me know.

-John Tjonasan-

<h1>Business/Flow Changes:</h1>

1.The original flow was a bit confusing so I decided to implement a menu system. Each menu item provides the user a clear idea of what selection they are making.

2.I also changed the flow to model what I feel the underlying data structure would be; namely many jokes belonging to one category.

2a.Because of this I  felt that the ability to swap a name in place of Chuck Norris, as well as the ability request up to 9 jokes fit better within the getJokes flow as opposed to the category listing flow.

3.I provided the option to sub in a name. As a default if there is no name provided Chuck Norris would be used

4.I also felt that providing a list of categories on their own wasn't very useful, so I created a get jokes by category menu item.


<h1>Technical Changes:</h1>

<b>Program.cs</b>

1.Used the Console class for writing.

2.Implemented some basic error handling

3.Broke logic into methods

4.Moved http client information to JsonFeed class

5. Simplified name replacement

<b>JsonFeed.cs</b>

1.Single instance of HttpClient

1a.Setting base url once

2.Used string builder to clean up dynamic URL creation

3.Created Dictionary to return list of categories, to allow user to select by choosing a menu number rather than typing a full category name

4.Simplified class to two calls

<h1>Future improvements:</h1>

1.More error handling
2.Remove duplicate jokes being returned
