using Microsoft.EntityFrameworkCore.Migrations;

namespace EventExplorer.Api.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Koncert');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Fesztivál');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Nyílt nap');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Pályaválasztási napok');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Vásár');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Színházi előadás');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Múzeumi kiállítás');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Szabadtéri program');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Mozi');");
            migrationBuilder.Sql("INSERT INTO categories (name) VALUES ('Cirkusz');");

            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('VOKE');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('BNSZ');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('SZTE');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('SZM');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('E78');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('Campus Fesztivál');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('AButik');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('MH');");
            migrationBuilder.Sql("INSERT INTO organizers (name) VALUES ('MoziVilág');");

            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('IH rendezvényközpont', 'Szeged', 'Felső Tisza-part 2', '6721', 500);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Szépművészeti Múzeum', 'Budapest', 'Dózsa György út 41.', '1146', 400);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Pécsi Tudományegyetem', 'Pécs', '48-as tér 1.', '7622', 530);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Zsolnay Negyed', 'Pécs', 'Felsővámház u. 52.', '7626', 200);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('VOKE Egyetértés Művelődési Központ', 'Debrecen', 'Faraktár u. 67', '4034', 300);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Nagyerdő', 'Debrecen', 'Nagyerdei krt. 5', '4032', 2000);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Budapesti Nemzeti Színház', 'Budapest', 'Bajor Gizi park 1.', '1095', 600);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Anita Butik Divatház', 'Szeged', 'Dózsa u 13.', '6720', 200);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Művészetek háza', 'Miskolc', 'Rákóczi Ferenc u. 5', '3530', 700);");
            migrationBuilder.Sql("INSERT INTO locations (name, city, address, zip_code, maximum_head_count) VALUES ('Ady Endre Központ', 'Miskolc', 'Árpád út 4', '3534', 400);");

            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'VOKE'), (SELECT id FROM categories WHERE name = 'Koncert'), 'Anyák Napi Musical', '2022-05-01 13:30:00', '2022-05-01 15:30:00', (SELECT id FROM locations WHERE name = 'VOKE Egyetértés Művelődési Központ'), 1500, 1);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'SZTE'), (SELECT id FROM categories WHERE name = 'Pályaválasztási napok'), 'Pályaválasztási Nap', '2022-09-13 09:30:00', '2022-09-13 11:30:00', (SELECT id FROM locations WHERE name = 'IH Rendezvényközpont'), 0, 1);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'SZM'), (SELECT id FROM categories WHERE name = 'Múzeumi kiállítás'), 'Régésztörténetek', '2022-12-15 20:00:00', '2022-012-015 22:30:00', (SELECT id FROM locations WHERE name = 'Szépművészeti Múzeum'), 2000, 1);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'E78'), (SELECT id FROM categories WHERE name = 'Koncert'), 'Metronóm Jazz Koncert', '2022-09-09 21:00:00', '2022-09-09 22:30:00', (SELECT id FROM locations WHERE name = 'Zsolnay Negyed'), 2800, 0);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'Campus Fesztivál'), (SELECT id FROM categories WHERE name = 'Fesztivál'), 'Campus Fesztivál 2022', '2022-05-07 10:00:00', '2022-05-09 10:00:00', (SELECT id FROM locations WHERE name = 'Nagyerdő'), 54990, 0);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'BNSZ'), (SELECT id FROM categories WHERE name = 'Színházi előadás'), 'Diótörő', '2022-12-14 18:00:00', '2022-12-14 20:00:00', (SELECT id FROM locations WHERE name = 'Budapesti Nemzeti Színház'), 5500, 1);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'AButik'), (SELECT id FROM categories WHERE name = 'Szabadtéri program'), 'Gardróbvásár', '2022-09-14 10:00:00', '2022-09-14 13:30:00', (SELECT id FROM locations WHERE name = 'Anita Butik Divatház'), 0, 0);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'MH'), (SELECT id FROM categories WHERE name = 'Koncert'), 'Szimfónikus koncert', '2022-10-01 14:30:00', '2022-10-01 17:30:00', (SELECT id FROM locations WHERE name = 'Művészetek háza'), 1000, 1);");
            migrationBuilder.Sql("INSERT INTO events (organizer_id, category_id, name, start_date, end_date, location_id, entrance_fee, is_indoor) VALUES ((SELECT id FROM organizers WHERE name = 'MoziVilág'), (SELECT id FROM categories WHERE name = 'Mozi'), 'MineCinema', '2022-10-02 16:00:00', '2022-10-02 18:30:00', (SELECT id FROM locations WHERE name = 'Ady Endre Központ'), 2500, 1);");

            migrationBuilder.Sql("INSERT INTO users (email, password, first_name, last_name, birth_date) VALUES ('juhasz.adel@gmail.com', '12345', 'Adél', 'Juhász', '2001-06-03 00:00:00');");
            migrationBuilder.Sql("INSERT INTO users (email, password, first_name, last_name, birth_date) VALUES ('racz.nikoletta@gamil.com', '123456', 'Nikoletta', 'Rácz', '2001-07-13 00:00:00');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM users;");
            migrationBuilder.Sql("DELETE FROM events;");
            migrationBuilder.Sql("DELETE FROM locations;");
            migrationBuilder.Sql("DELETE FROM organizers;");
            migrationBuilder.Sql("DELETE FROM categories;");
        }
    }
}
