/**
* *
* @author fengshengde
* @created 
* @version 0.1
* 
*页面公用javascript方法
* 
*/
function openTab(id, title, url) {
    var node = {
        attributes: {
            href: url
        },
        text: title,
        id: id
    };
    parent.addExampleTab.apply(parent, [node]);
}