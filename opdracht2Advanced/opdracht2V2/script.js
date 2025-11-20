fetch("02 collectible_cards (1).csv")
    .then(response => response.text())
    .then(text => {
        const rows = text.split("\n").slice(1);
        let outputHTML = "";

        for (let i = 0; i < rows.length; i++) {
            const columns = rows[i].split(",");
            const name = columns[0];
            const cost = columns[1];
            const picture = columns[2];

            outputHTML += `
                <div style="margin-bottom: 20px;">
                    <strong>${name}</strong><br>
                    Price: ${cost}<br>
                    <img src="${picture}" alt="${name}" style="max-width:200px;">
                </div>
            `;
        }

        document.getElementById("output").innerHTML = outputHTML;
    });