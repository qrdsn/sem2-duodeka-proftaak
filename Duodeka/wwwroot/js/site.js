const host = window.location.protocol + "//" + window.location.hostname + ":" + window.location.port;

function getSingleFromTemplate(data, template)
{
    //find the template
    var itemTpl = $('script[data-template="' + template + '"]').text().split(/\$\{(.+?)\}/g);

    //set render properties into template
    let render = props => {
        return function (tok, i) { return (i % 2) ? props[tok] : tok; };
    }

    return itemTpl.map(render(data)).join('');
}

function LoadSingleFromTemplate(data, template, target)
{
    $('#' + target).append(getSingleFromTemplate(data, template));
}

function LoadFromTemplate(data, template, target)
{
    //execute on data
    $('#' + target).append(data.map(item => {
        return getSingleFromTemplate(item, template);
    }));
}

function showMessage(message, priority)
{
    LoadSingleFromTemplate({ body: message, priority: priority }, "messageTemplate", "messageContainer");
}